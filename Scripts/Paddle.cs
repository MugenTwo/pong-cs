using Godot;
using System;

public class Paddle : Area2D
{

    private static readonly String INPUT_MOVE_UP_SUFFIX = "MoveUp";
    private static readonly String INPUT_MOVE_DOWN_SUFFIX = "MoveDown";
    [Export]
    private int speed = 250;
    [Export]
    private int ballDirection = 1;
    private RandomNumberGenerator randomNumberGenerator;

    public override void _Ready()
    {
        this.randomNumberGenerator = new RandomNumberGenerator();
    }

    public override void _Process(float delta)
    {
        String name = this.Name;
        Vector2 currentPosition = this.Position;

        if (Input.IsActionPressed(name + INPUT_MOVE_UP_SUFFIX) && currentPosition.y > 40)
        {
            currentPosition = new Vector2(currentPosition.x, currentPosition.y - speed * delta);
        }

        if (Input.IsActionPressed(name + INPUT_MOVE_DOWN_SUFFIX) && currentPosition.y < 560)
        {
            currentPosition = new Vector2(currentPosition.x, currentPosition.y + speed * delta);
        }

        this.Position = currentPosition;
    }

    public void OnPaddleAreaEntered(Area2D area)
    {
        if (area.Name.Equals("ball"))
        {
            Ball ball = area as Ball;
            Vector2 newDirection = new Vector2(ballDirection, this.randomNumberGenerator.Randf() * 2 - 1).Normalized();
            ball.currentDirection = newDirection;
        }
    }

}
