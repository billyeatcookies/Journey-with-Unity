using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rb;
    public float multiply;
    public float moveForce;
    public float turnTorque;

    private const float TurnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;

    private float _horizontal;
    private float _vertical;
    private void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    public Transform[] anchors = new Transform[4];
    private readonly RaycastHit[] _hits = new RaycastHit[4];

    private void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        for (var i = 0; i < 4; i++)
            ApplyForce(anchors[i], _hits[i]);

        _rb.AddForce(_vertical * moveForce * transform.right);
        _rb.AddTorque(Input.GetAxis("Horizontal") * turnTorque * transform.up);
    }

    private void ApplyForce(Transform anchor, RaycastHit hit)
    {
        if (!Physics.Raycast(anchor.position, -anchor.up, out hit)) return;
        var position = anchor.position;
        var force = Mathf.Abs(1 / (hit.point.y - position.y));
        _rb.AddForceAtPosition(transform.up * (force * multiply), position, ForceMode.Acceleration);
        
        DrawLine(position, hit.point);
    }
    
    private static void DrawLine(Vector3 startPoint, Vector3 endPoint) => Debug.DrawLine(startPoint, endPoint, Color.red);

    // private void Update()
    // {
    //     _horizontal = Input.GetAxisRaw("Horizontal");
    //     _vertical = Input.GetAxisRaw("Vertical");
    //     var direction = new Vector3(_horizontal, 0f, _vertical).normalized;
    //
    //     if (!(direction.magnitude >= 0.1f)) return;
    //     var targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
    //     var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity,
    //         TurnSmoothTime);
    //     var rotation = transform.rotation;
    //     rotation = Quaternion.Euler(rotation.x, angle, rotation.z);
    //     transform.rotation = rotation;
    // }
}
    
        
