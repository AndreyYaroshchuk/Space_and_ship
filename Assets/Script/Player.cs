using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string TRIGGER_DIE = "Die";

    private Rigidbody rb;

    private float maxRotation = 45f;
    private float rotatiobSpeed = 3f;
    private float currentRotaionZ = 0f;

    private static float healthPlayer = 3f;
    private static float speedStart;
    private const float fieldPlayTop = -33f;
    private const float fieldPlayUpper = 86f;
    private const float fieldPlayLeft = -110f;
    private const float fieldPlayRight = 110f;

    public event EventHandler OnGameOverPlayer;

    [SerializeField] private Animator animator;
    [SerializeField] private static float speed = 10f;
    [SerializeField] private Light lights;

    public static float HealthPlayer { get => healthPlayer; set => healthPlayer = value; }
    public static float Speed { get => speed; set => speed = value; }
    public static float SpeedStart { get => speedStart; set => speedStart = value; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        SpeedStart = Speed;
    }
    private void Start()
    {
        LevelObjects.OnDamagePlayer += LevelObjects_OnDamagePlayer;
    }
    private void Update()
    {
        Movet();
        Die();
    }
    private void LevelObjects_OnDamagePlayer(object sender, System.EventArgs e)
    {
        animator.SetTrigger(TRIGGER_DIE);
    }


    private void Movet()
    {
        if (transform.position.z > fieldPlayTop && transform.position.z < fieldPlayUpper && transform.position.x > fieldPlayLeft && transform.position.x < fieldPlayRight)
        {
            float sideForce = Input.GetAxis("Horizontal") * Speed;
            float forwardForce = Input.GetAxis("Vertical") * Speed;
            rb.AddForce(sideForce, 0f, forwardForce);

            float RotationZ = currentRotaionZ - sideForce * rotatiobSpeed;

            RotationZ = Mathf.Clamp(RotationZ, -maxRotation, maxRotation); // огроничитель поворота 

            currentRotaionZ = Mathf.Lerp(currentRotaionZ, RotationZ, Time.deltaTime * rotatiobSpeed);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentRotaionZ);

            if (Input.GetAxis("Vertical") != 0)
            {
                Speed = SpeedStart * 2f;
                lights.type = LightType.Directional;
                lights.intensity = 500f;

            }
            else
            {
                Speed = SpeedStart;
                lights.type = LightType.Point;
                lights.intensity = 5000f;
            }
        }
        else
        {
            HealthPlayer--;
            transform.position = Vector3.zero;
            animator.SetTrigger(TRIGGER_DIE);
        }
    }
    private void Die()
    {
        if (HealthPlayer <= 0f)
        {
            Destroy(gameObject);
            OnGameOverPlayer?.Invoke(this, EventArgs.Empty);
        }
    }
}
