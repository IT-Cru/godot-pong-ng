using Godot;

namespace PongNG.scripts;

public partial class Wall : Area2D
{
    [Export]
    public Vector2 BallResetDirection = Vector2.Left;

    [Export]
    public Node2D Scorer { get; set; }

    private void OnAreaEntered(Area2D area)
    {
        if (area is not Ball ball) return;
        ball.Reset(BallResetDirection);
        if (Scorer is IHasScore scoring)
        {
            scoring.IncrementScore();
        }
    }
}