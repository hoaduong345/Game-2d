using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float velocityMovement;

    [SerializeField] private float distance;

    [SerializeField] private LayerMask CullingMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(velocityMovement * transform.right.x, rb.velocity.y);

        RaycastHit2D infomationTerrian = Physics2D.Raycast(transform.position, transform.right, distance, CullingMask);

        if (infomationTerrian)
        {
            Girar();
        }
    }

    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * distance);

    }
}
