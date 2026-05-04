using UnityEngine;

public class Missle : MovingObject
{
    public float MoveSpeed = 35f;


    public override void Initalize()
    {
        base.Initalize();

        AddLineToObject(new Vector3(2, 0, 0), new Vector3(-2, 2, 0), Color.yellow);
        AddLineToObject(new Vector3(-2, 2, 0), new Vector3(-1, 0, 0), Color.yellow);
        AddLineToObject(new Vector3(-1, 0, 0), new Vector3(-2, -2, 0), Color.yellow);
        AddLineToObject(new Vector3(-2, -2, 0), new Vector3(2, 0, 0), Color.yellow);

    }
    public override void Tick()
    {
        base.Tick();

        if (CheckForCollisionWith(SpaceWarGrid.self.ShipAObject))
        {
            Debug.Log("Hit Ship A");
            SpaceWarGrid.self.PlayerBScore++;
            SpaceWarGrid.self.RemoveMovingObject(this);
        }
        if (CheckForCollisionWith(SpaceWarGrid.self.ShipBObject))
        {
            Debug.Log("Hit Ship B");
            SpaceWarGrid.self.PlayerAScore++;
            SpaceWarGrid.self.RemoveMovingObject(this);
            if (CollisionCircle != null)
            {
                SpaceWarGrid.self.RemoveMovingObject(CollisionCircle);
            }
        }
    }
    public void RemoveMissle()
    {
        SpaceWarGrid.self.RemoveMovingObject(this);
        if (CollisionCircle != null) { SpaceWarGrid.self.RemoveMovingObject(CollisionCircle);}
    }

    public void MakeMissle(float angle, Vector3 spawnPosition, Grid grid, int sceneIndex)
    {
        Missle missle = new Missle();
    }
    public void LaunchMissle(float angle)
    {
        SetRotationinDegrees(angle); 
        Velocity = DrawingTools.CircleRadiusPoint(Vector3.zero, angle, 1) * MoveSpeed; 
    }
}
