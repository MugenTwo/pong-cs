using Godot;

public class Exit : Area2D
{

    public void OnExitAreaEntered(Area2D area)
    {
        if (area.Name.Equals("ball"))
        {
            Ball ball = area as Ball;
            ball.Reset();
        }
    }

}
