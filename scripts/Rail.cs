using Godot;

namespace PongNG.scripts;

public partial class Rail : Area2D
{
	[Export]
	private int _bounceDirection = 1;

	private void OnAreaEntered(Area2D area)
	{
		if (area is not Ball ball) return;
		var direction = (ball.Direction + new Vector2(0, _bounceDirection)).Normalized();
		ball.Bounce(direction);
	}
}
