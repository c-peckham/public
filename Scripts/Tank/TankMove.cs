using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {

	public int m_PlayerNumber = 1;
	public float m_Speed = 12f;
	public float m_TurnSpeed = 180f;
	public AudioSource m_movementAudio;
	public AudioClip m_EngineIdling;
	public AudioClip m_EngineDriving;
	public float m_PitchRange = 0.2f;

	private string m_MovementAxisName;
	private string m_TurnAxisName;
	private Rigidbody m_Rigidbody;
	private float m_MovementInputValue;
	private float m_TurnInputValue;
	private float m_OriginalPitch;

	private void Awake()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();

	}

	private void OnEnable()
	{
		m_Rigidbody.isKinematic = false;

		m_MovementInputValue = 0f;
		m_TurnInputValue = 0f;
	}

	private void Start ()
	{
		m_MovementAxisName = "Vertical" + m_PlayerNumber;
		m_TurnAxisName = "Horizontal" + m_PlayerNumber;

		m_OriginalPitch = m_movementAudio.pitch;
	}

	private void Update()
	{
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

		EngineAudio ();
	}

	private void EngineAudio ()
	{
		if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f) {
			if (m_movementAudio.clip == m_EngineDriving) {
				m_movementAudio.clip = m_EngineIdling;
				m_movementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_movementAudio.Play ();
			}
		} else {
			if (m_movementAudio.clip == m_EngineIdling) {
				m_movementAudio.clip = m_EngineDriving;
				m_movementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_movementAudio.Play ();
			}
		}
	}
	private void FixedUpdate()
	{
		Move ();
		Turn ();
	}

	private void Move()
	{
		Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
		m_Rigidbody.MovePosition (m_Rigidbody.position + movement);
	}

	private void Turn()
	{
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
	}
}