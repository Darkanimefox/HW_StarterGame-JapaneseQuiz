using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    [SerializeField]
	public AudioSource startSound;

	void Start () {
		startSound.Play();
        Destroy(gameObject, 2);
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
