using UnityEngine;
using DG.Tweening;
public class Swipe : MonoBehaviour 
{
	[SerializeField] protected Car carPrefab;			// Ball prefab to spawn ball to throw
	[SerializeField] protected Trajectory trajectory;	// Trajectory will be drawn
	[SerializeField] protected float pushForce;			// Push vector multiplier
	[SerializeField] protected float maxForce;			// You can limit the force with this
	[SerializeField] [Range(0f, 10f)] protected float zMultiplier;	// How much the 'y' of force vector impacts the 'z' of force vector.
																	// If you want to throw only on 2D Space, set this as 0 (zero).
	
	private Vector2 _startPos, _endPos;	// Screen points to calculate Force vector
	private Vector3 _forcevector;		// Force vector to apply ball
	public Car _car;                 // Ball to throw

	//private GameManager gameManager;

	//[SerializeField] private Animator animator;

	private float _carZvalue, ropeHolderZValue;
	float carBackBoundValue, ropeHolderBoundValue;


	Vector2 slingVec;
	//[HideInInspector]
	//public bool isThrow;

	private float speed = 0.5f;

    public GameObject slingRopeRight, slingRopeLeft;

    private Quaternion rightRopeRot, leftRopeRot;


	public GameObject ropeHolder;

	float distanceSling;
	private void Awake()
    {
		//gameManager = FindObjectOfType<GameManager>();
	}

    private void Start() {

		_carZvalue = _car.transform.position.z;
        rightRopeRot = slingRopeRight.transform.rotation;
        leftRopeRot = slingRopeLeft.transform.rotation;

        ropeHolderZValue = ropeHolder.transform.position.z;



        //Debug.Log("carZ Value" + _carZvalue);

	}

    private void OnEnable()
    {
		//isThrow = true;
		//Spawn();
	}

    private void Update() {
		ControlSwipe();
	}

	private void ControlSwipe() {
		// Starting to drag
		if (Input.GetMouseButtonDown(0)) {
			// Starting to showing trajectory
			trajectory.Show();
		
			// Taking first point on screen for force vector
			_startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

			//animator.SetInteger("idle", 0);
			//animator.SetInteger("throw", 1);
			//isThrow = false;
			//_ball.transform.gameObject.SetActive(true);
			distanceSling = 0;
		}

		// Dragging
        if (Input.GetMouseButton(0)) {
			// Taking secnd point on screen for force vector
			Debug.Log("endPos : " + _endPos);

			_endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

            

			// Direction and distance
			Vector3 direction = (_startPos - _endPos).normalized;
			float distance = Vector2.Distance(_startPos, _endPos);


			trajectory.UpdateDots(_car.transform.position, _forcevector);

			// Determining Force Vector
			_forcevector = direction * distance * pushForce;
            _forcevector.z = _forcevector.y * zMultiplier;

			_forcevector = new Vector3(_forcevector.x, transform.position.y, _forcevector.z);

			//Debug.Log("distance : " + distance + "forcevector : " + _forcevector);

			if (_endPos != slingVec )
			{
				distanceSling = Vector2.Distance(_startPos, slingVec);

				distanceSling = Mathf.Clamp(distanceSling, 0, 0.3f);
				Debug.Log("distanceSling : " + distanceSling);
                //if (distanceSling != 0.3f)
                //{

                    slingVec = Camera.main.ScreenToViewportPoint(Input.mousePosition);

				//car position change
					carBackBoundValue = _car.transform.position.z - (distanceSling / 5);
					ropeHolderBoundValue = ropeHolder.transform.position.z -(distanceSling / 5);

					carBackBoundValue = Mathf.Clamp(carBackBoundValue, _carZvalue - 4, _carZvalue);
				ropeHolderBoundValue = Mathf.Clamp(ropeHolderBoundValue, ropeHolderZValue - 4, ropeHolderZValue);

					_car.transform.position = new Vector3(_car.transform.position.x, _car.transform.position.y, carBackBoundValue);

				ropeHolder.transform.position = new Vector3(ropeHolder.transform.position.x, ropeHolder.transform.position.y, ropeHolderBoundValue);


                //rope Scale change
                if (carBackBoundValue != _carZvalue-4)
                {
					slingRopeRight.transform.localScale =
						new Vector3(slingRopeRight.transform.localScale.x,//- (distanceSling / 25)
						slingRopeRight.transform.localScale.y,//+ (distanceSling / 3)
						slingRopeRight.transform.localScale.z + (distanceSling /18));

					//rope rotation change
					rightRopeRot = Quaternion.Euler(rightRopeRot.eulerAngles.x, rightRopeRot.eulerAngles.y - (distanceSling * 1.28f), rightRopeRot.eulerAngles.z);
					slingRopeRight.transform.rotation = rightRopeRot;

					slingRopeLeft.transform.localScale =
						new Vector3(slingRopeLeft.transform.localScale.x,//- (distanceSling / 25)
						slingRopeLeft.transform.localScale.y,//+ (distanceSling / 3)
						slingRopeLeft.transform.localScale.z + (distanceSling / 18));

					leftRopeRot = Quaternion.Euler(leftRopeRot.eulerAngles.x, leftRopeRot.eulerAngles.y + (distanceSling * 1.28f), leftRopeRot.eulerAngles.z);
					slingRopeLeft.transform.rotation = leftRopeRot;
				}
					

                    //slingRopeRight.transform.LookAt(rightRopeRotTarget);
                //}


            }

			



			//Debug.Log("carBackBoundValue : " + carBackBoundValue);
   //         Vector3 pos = _car.transform.position;

			//pos.x = Mathf.Clamp(_car.transform.position.x, _car.transform.position.x - distance, _car.transform.position.x);

			//_car.transform.position = pos;

            //float animationValue = Mathf.Clamp(distance, 0, 0.6f);
            //float cameraRotation = Mathf.Clamp(_forcevector.x,  -10, 10);

            //         if (animationValue > 0.1f)
            //         {
            //             _ball.gameObject.SetActive(true);
            //         }


            //         Quaternion quaternionTarget = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, yValue + cameraRotation / 10, Camera.main.transform.rotation.eulerAngles.z);
            //         Quaternion quaternionTargetHand = Quaternion.Euler(Camera.main.transform.rotation.eulerAngles.x, yValue + cameraRotation , Camera.main.transform.rotation.eulerAngles.z);

            //         Camera.main.transform.rotation = quaternionTarget;

            //animator.transform.rotation = quaternionTargetHand;



            //animator.Play("throw", 0, animationValue);

            //_forcevector = Vector3.ClampMagnitude(_forcevector, maxForce);

            // Updating positions of dots acc to Force vector starting with ball position
        }

		// End the dragging and push the ball
		if (Input.GetMouseButtonUp(0)) {
            //if (_car) {
            //	// Appling Force vector to the ball
            //	_car.Push(_forcevector);
            //	_car = null;

            //             // Spawning a new ball to throw
            //             //Invoke("Spawn", 1);
            //             Destroy(_car, 0.5f);
            //}

            // Hiding the trajectory
            _car.Push(_forcevector);

            trajectory.Hide();

			ThrowCar();
			//animator.SetInteger("idle", 1);
			//animator.SetInteger("throw", 0);

			//gameManager.currentBall = null;

			//isThrow = true;

            //transform.gameObject.SetActive(false);
            //gameManager.currentSwipe = otherHand.GetComponent<Swipe>();
        }
	}

	// Spawns a new ball
	public void Spawn() {

		_car = Instantiate(carPrefab, transform.position, Quaternion.identity);
		//_ball.gameObject.SetActive(false);
			
	}

	private void ThrowCar()
    {
        ropeHolder.transform.DOMoveZ(ropeHolder.transform.position.z + 12, 0.5f);
        slingRopeLeft.transform.DORotate(new Vector3(0, -130, 0), 0.5f, RotateMode.LocalAxisAdd).OnStart(() => 
		{
			slingRopeLeft.transform.DOScaleZ(0.5f, 0.25f).OnComplete(() =>
			 {
				 slingRopeLeft.transform.DOScaleZ(2.3f, 0.25f);
			 });
		});

        slingRopeRight.transform.DORotate(new Vector3(0, 130), 0.5f, RotateMode.LocalAxisAdd).OnStart(() =>
		{
			slingRopeRight.transform.DOScaleZ(0.5f, 0.25f).OnComplete(() =>
			{
				slingRopeRight.transform.DOScaleZ(2.3f, 0.25f);
			});
		});


	}
}
