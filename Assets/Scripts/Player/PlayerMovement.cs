using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	int ID_Walk = Animator.StringToHash("IsWalking");
	private Rigidbody playerRigidbody;
	private int floorMask;
	private Camera _cam;
	private float camRayLength = 100f;

	bool movePressed;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		_cam = Camera.main;
	}

	void FixedUpdate()
	{
		/*float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");*/

		MovePosition();
		Turning();
		//Animating(h, v);
	}

	void MovePosition()
	{
        playerRigidbody.MovePosition(transform.position + (movement * speed * Time.deltaTime));
        Animating();
    }

	public void Move(InputAction.CallbackContext ctx/*float h, float v*/)
	{
		Vector2 moveDirection = ctx.ReadValue<Vector2>();
		//movement.Set(moveDirection.x, 0f, moveDirection.y);
		movement = new Vector3 (moveDirection.x, 0f, moveDirection.y);

		
    }

	void Turning()
	{
		Ray camRay = _cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating()
	{
		bool walking = movement.x != 0f || movement.z != 0f;

		anim.SetBool(ID_Walk, walking);
	}
}
