using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	public float startScaleAmount;
	public float scaleAmount = 10;
	public float startScaleIntensityAmount;
	public float scaleIntensityAmount = 0.5f;

	public float interval = 0.1f;
	private float lastTime = 0;

	// Update is called once per frame
	void Update () {
	
		if (lastTime + interval <= Time.time)
		{
			lastTime = Time.time;

			gameObject.light.range = Random.Range(startScaleAmount, scaleAmount);
			gameObject.light.intensity = Random.Range(startScaleIntensityAmount, scaleIntensityAmount);

		}

	}
}
