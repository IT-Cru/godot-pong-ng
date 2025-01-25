using System;
using Godot;

namespace PongNG.scripts;

public partial class Enemy : Area2D, IHasScore
{
    [Export]
    private Area2D _follow;

    [Export]
    private float _difficulty = 0.3f;

    public int Score { get; set; }

    [Export]
    public Label ScoreDisplay { get; set; }

    public AudioStreamPlayer ScoreSound { get; set; }

    public override void _Ready()
    {
        ScoreSound = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
    }

    public override void _PhysicsProcess(double delta)
    {
        Position = Position with
        {
            // don't leave the play field
            Y = Math.Clamp(Position.Lerp(_follow.Position, _difficulty / 10).Y, 16, GetViewportRect().Size.Y - 16)
        };
    }

    private static void OnAreaEntered(Area2D area)
    {
        if (area is not Ball ball) return;
        var direction = new Vector2(Vector2.Left.X, (float)Random.Shared.NextDouble() * 2 - 1).Normalized();
        ball.Bounce(direction);
    }
}
