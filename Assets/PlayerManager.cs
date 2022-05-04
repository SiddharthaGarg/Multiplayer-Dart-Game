using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerManager : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;
    [SerializeField] private GameObject gameOverscreen;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;

    bool readyToThrow;
    //score text
    public static int scoreCount = 0;
    [SerializeField] private TextMeshProUGUI score_text;
    [SerializeField] private TextMeshProUGUI DartText;
    public static bool input_enabled = true;
    private void Start()
    {
        input_enabled = true;
        readyToThrow = true;
        scoreCount = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0 && input_enabled)
        {
            Throw();
        }
        if (totalThrows <= 0 && input_enabled)
        {
            input_enabled = false;
            readyToThrow = false;
            Invoke(nameof(GameOver), 2f);
        }
        DartText.text = "Darts: " + totalThrows.ToString();
        score_text.text = "SCORE: " + scoreCount.ToString();
    }

    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force 
        Vector3 forceToAdd = forceDirection * throwForce;
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
    public void GameOver()
    {
        gameOverscreen.SetActive(true);
    }
}