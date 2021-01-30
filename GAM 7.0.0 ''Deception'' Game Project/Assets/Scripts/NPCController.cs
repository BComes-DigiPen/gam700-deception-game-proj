using UnityEngine;

public class NPCController : MonoBehaviour
{
	private float Timer;
	public float Speed = 1;
	private float SpeedMultiplier;
	private RunnerShared RS;

	private void Start()
	{
		RS = GetComponent<RunnerShared>();
		if (!RS.IsNPC())
			RS.ToggleNPCState();
		SpeedMultiplier = Random.Range(50, 150) / 100f;
		Timer = Random.Range(100, 500) / 100f;
	}

	private void Update()
	{
		if (!RS.IsDead())
		{
			// Swap state when timer is up
			if (Timer <= 0)
			{
				ToggleState();
				float temp = Random.Range(25, 150) / 100.0f;
				Timer = RS.MovementState == RunnerShared.MovementStates.Walking ? temp * temp * SpeedMultiplier : temp * temp / SpeedMultiplier;
				if (RS.MovementState == RunnerShared.MovementStates.Walking)
					RS.RB2D.velocity = Vector2.right * Speed;
				else
					RS.RB2D.velocity = Vector2.zero;
			}
			else
				Timer -= Time.deltaTime;
		}
	}

	private void ToggleState()
	{
		RS.MovementState = RS.MovementState == RunnerShared.MovementStates.Idle ? RunnerShared.MovementStates.Walking : RunnerShared.MovementStates.Idle;
	}
}