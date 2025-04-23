using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace DoorScript
{
	[RequireComponent(typeof(AudioSource))]


	public class Door : MonoBehaviour {
		public bool open;
		public float smooth = 1.0f;
		float DoorOpenAngle = -90.0f;
		float DoorCloseAngle = 0.0f;
		public float closeTime;
		public AudioSource asource;
		public AudioClip openDoor, closeDoor;
		public GameObject cameraOld;
		public GameObject cameraNew;
		public GameObject Player;
		public GameObject spookyGhost;
		public GameObject Collider;
        public GameObject UI;

        [SerializeField] public box box;

        // Use this for initialization
        void Start() {
			asource = GetComponent<AudioSource>();
		}

		// Update is called once per frame
		void Update() {
			if (open)
			{
				var target = Quaternion.Euler(0, DoorOpenAngle, 0);
				transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * 5 * smooth);

			}
			else
			{
				var target1 = Quaternion.Euler(0, DoorCloseAngle, 0);
				transform.localRotation = Quaternion.Slerp(transform.localRotation, target1, Time.deltaTime * 5 * smooth);

			}
			if (box.isIn == true)
			{ 
				Debug.Log("Works");
				
				if (Input.GetKeyDown(KeyCode.E))
				{
					transform.GetComponent<DoorScript.Door>().OpenDoor();
					cameraOld.SetActive(false);
					cameraNew.SetActive(true);
					StartCoroutine(Cutscene());
				}
			}
           
        }

		public void OpenDoor() {
			open = !open;
			asource.clip = open ? openDoor : closeDoor;
			asource.Play();
		}

        private IEnumerator Cutscene()
		{
            yield return new WaitForSeconds(.01f);
            Player.SetActive(false);
            UI.SetActive(false);
            spookyGhost.SetActive(true);
			yield return new WaitForSeconds(closeTime);
			smooth = 3f;
			open = false;
			spookyGhost.SetActive(false);
			Player.SetActive(true);
			yield return new WaitForSeconds(0.1f);
            cameraNew.SetActive(false);
            cameraOld.SetActive(true);
            

        }
}
}