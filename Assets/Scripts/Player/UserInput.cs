using UnityEngine;
using System.Collections;
using RTS;

public class UserInput : MonoBehaviour {

	private Player player;

	// Use this for initialization
	void Start () {
		player = transform.root.GetComponent< Player> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.human) {
			MoveCamera();
		}
	}
	
	private void MoveCamera() {
		float xpos = Input.mousePosition.x;
		float ypos = Input.mousePosition.y;
		Vector3 movement = new Vector3(0,0,0);

		//horizontal camera movement
		if(xpos < ResourceManager.ScrollWidth) {
			movement.x -= ResourceManager.ScrollSpeed;
		} else if(xpos > Screen.width - ResourceManager.ScrollWidth) {
			movement.x += ResourceManager.ScrollSpeed;
		}
		
		//vertical camera movement
		if(ypos < ResourceManager.ScrollWidth) {
			movement.y -= ResourceManager.ScrollSpeed;
		} else if(ypos > Screen.height - ResourceManager.ScrollWidth) {
			movement.y += ResourceManager.ScrollSpeed;
		}

		movement = Camera.mainCamera.transform.TransformDirection(movement);

		movement.z = 0;

		Vector3 origin = Camera.mainCamera.transform.position;
		Vector3 destination = origin;
		destination.x += movement.x;
		destination.y += movement.y;
		destination.z += movement.z;

		movement.y -= ResourceManager.ZoomSpeed * Input.GetAxis("Mouse ScrollWheel");
		Camera.mainCamera.orthographicSize -= ResourceManager.ScrollSpeed * Input.GetAxis("Mouse ScrollWheel");

		if(Camera.mainCamera.orthographicSize > ResourceManager.MaxCameraHeight) {
			Camera.mainCamera.orthographicSize = ResourceManager.MaxCameraHeight;
		} else if(Camera.mainCamera.orthographicSize < ResourceManager.MinCameraHeight) {
			Camera.mainCamera.orthographicSize = ResourceManager.MinCameraHeight;
		}

		if(destination.x > ResourceManager.MaxCameraX) {
			destination.x = ResourceManager.MaxCameraX;
		} else if(destination.x < (-1*ResourceManager.MaxCameraX)){
			destination.x = -1*ResourceManager.MaxCameraX;
		}

		if(destination.y > ResourceManager.MaxCameraY) {
			destination.y = ResourceManager.MaxCameraY;
		} else if(destination.y < (-1*ResourceManager.MaxCameraY)){
			destination.y = -1*ResourceManager.MaxCameraY;
		}

		if(destination != origin) {
			Camera.mainCamera.transform.position = Vector3.MoveTowards(origin, destination, Time.deltaTime * ResourceManager.ScrollSpeed * Mathf.Abs(Camera.mainCamera.orthographicSize));
		}
	}

}
