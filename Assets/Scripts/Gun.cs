using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform launchPostition;
	public bool isUpgraded;
	public float upgradeTime = 10.0f;
	private float currentTime;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (!IsInvoking ("FireBullet")) {
				InvokeRepeating ("FireBullet", 0f, 0.1f);
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			CancelInvoke ("FireBullet");
		}

		currentTime += Time.deltaTime;
		if (currentTime > upgradeTime && isUpgraded) {
			isUpgraded = false;
		}
	}

	void FireBullet() {
		Rigidbody bullet = CreateBullet ();
		bullet.velocity = transform.parent.forward * 100;

		if (isUpgraded) {
			Rigidbody bullet2 = CreateBullet ();
			bullet2.velocity = (transform.right + transform.forward / 0.5f) * 100;
			Rigidbody bullet3 = CreateBullet ();
			bullet3.velocity = ((transform.right * -1) + transform.forward / 0.5f) * 100;
		}

		if (isUpgraded) {
			audioSource.PlayOneShot (SoundManager.Instance.upgradedGunFire);
		} else {
			audioSource.PlayOneShot (SoundManager.Instance.gunFire);
		}
	}

	private Rigidbody CreateBullet() {
		GameObject bullet = Instantiate (bulletPrefab) as GameObject;
		bullet.transform.position = launchPostition.position;
		return bullet.GetComponent<Rigidbody> ();
	}

	public void UpgradeGun() {
		isUpgraded = true;
		currentTime = 0;
	}
}
