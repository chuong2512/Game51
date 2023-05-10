using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {
    private Rigidbody2D _rigidBody;
    private bool _isMoving;

    public float speed;
    public AimingShotLine line;

	// Use this for initialization
	void Start () {
        _rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!_isMoving)
            mouseControl();
        if (_rigidBody.velocity.magnitude < 5)
        {
            _isMoving = false;
            _rigidBody.velocity = Vector2.zero;
        }
	}

    public void Shoot(Vector3 force){
        _rigidBody.AddForce(new Vector2(force.x, force.y), ForceMode2D.Force);
        _isMoving = true;
    }

    void mouseControl(){
        if (Input.GetMouseButtonUp(0))
        {
            Shoot(speed * (Input.mousePosition - transform.position).normalized * 1000);
            return;
        }

        if(Input.GetMouseButton(0))
        {
            transform.up = Input.mousePosition - transform.position;    
        }
    }
}
