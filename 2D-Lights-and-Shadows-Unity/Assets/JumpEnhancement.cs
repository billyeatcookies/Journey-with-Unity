using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnhancement : MonoBehaviour
{
    public float fallMultiplier = 2.5f;

    public float lowFallMultiplier = 2f;

    private Rigidbody2D _body;
    
    // Start is called before the first frame update
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_body.velocity.y < 0)
        {
            _body.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }else if (_body.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _body.velocity += Vector2.up * (Physics2D.gravity.y * (lowFallMultiplier - 1) * Time.deltaTime);
        }
    }
}
