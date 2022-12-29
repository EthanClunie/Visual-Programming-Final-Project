using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	public static CameraShake Instance;
	public Transform camTransform;

	private Vector3 _originalPos;
	private float _timeAtCurrentFrame;
	private float _timeAtLastFrame;
	private float _fakeDelta;

    private void Awake()
    {
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}
		
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}

	}

	void Update()
	{
		// Calculate a fake delta time, so we can Shake while game is paused.
		_timeAtCurrentFrame = Time.realtimeSinceStartup;
		_fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
		_timeAtLastFrame = _timeAtCurrentFrame;
	}

	private void OnLevelWasLoaded(int level)
	{
		camTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

    }

	public static void Shake(float duration, float magnitude)
	{
		Instance._originalPos = Instance.gameObject.transform.localPosition;
		Instance.StopAllCoroutines();
		Instance.StartCoroutine(Instance.cShake(duration, magnitude));
	}

	public IEnumerator cShake(float duration, float magnitude)
	{
		float endTime = Time.time + duration;

		while (duration > 0)
		{
			transform.localPosition = _originalPos + Random.insideUnitSphere * magnitude;

			duration -= _fakeDelta;

			yield return null;
		}

		transform.localPosition = _originalPos;
	}

}
