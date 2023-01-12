using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject bladeTrailPrefab;
    bool isCutting;
    Camera cam;
    [SerializeField] bool isTrailActive = true;
    GameObject currentBladeTrail;
    [SerializeField]
    float minCuttingVelocity;

    Vector2 previousPosition;
    CircleCollider2D circleCollider2D;
    Rigidbody2D rb;
    private void Start()
    {
        cam = Camera.main;
        isCutting = false;
        rb = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        //Debug.Log(Input.mousePosition);

        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }
        if (isCutting)
            UpdateCut();
    }
    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if (velocity >= minCuttingVelocity)
        {
            circleCollider2D.enabled = true;
        }
        else
        {
            circleCollider2D.enabled = false;
        }
        previousPosition = newPosition;
    }
    void StartCutting()
    {
        //UpdateCut();
        isCutting = true;
        circleCollider2D.enabled = false;
        if (isTrailActive)
            currentBladeTrail = Instantiate(bladeTrailPrefab, transform);

    }
    void StopCutting()
    {
        isCutting = false;
        if (isTrailActive && currentBladeTrail != null)
            currentBladeTrail.transform.SetParent(null);
        circleCollider2D.enabled = false;
    }
}
