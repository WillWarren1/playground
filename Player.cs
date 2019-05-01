using Godot;
using System;

public class Player : KinematicBody2D
{
  [Export] public int Speed = 500;

  Vector2 velocity = new Vector2();

  public void GetInput()
  {
    LookAt(GetGlobalMousePosition());

    velocity = new Vector2();

    if (Input.IsActionPressed("down"))
      velocity = new Vector2(-Speed, 0).Rotated(Rotation);

    if (Input.IsActionPressed("up"))
      velocity = new Vector2(Speed, 0).Rotated(Rotation);

    velocity = velocity.Normalized() * Speed;
  }

  public override void _PhysicsProcess(float delta)
  {
    GetInput();

    MoveAndSlide(velocity);
  }
}
