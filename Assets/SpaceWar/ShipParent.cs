using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipParent : MovingObject
{
    public DrawableObject ship;
    public DrawableObject thrust;
    
    public float ShipMaxVelocity = 250;
    public float ShipThrust = 25f;
    public float ShipRoation = 90f;
    public bool IsDrawingLaser = false;
    public float MissleLaunchAt = 13f;

    Line LaserObject;
    public float LaserStart = 5f;
    public float LaserEnd = 100f;
    public float LaserShowTime = .5f;
    public float LaserShowCounter = 0;

    public void SetupA(DrawableGrid grid, int sceneIndex)
    {
        ship = new ShipA();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipAThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity;

        LaserObject = new Line();
        LaserObject.color = Color.yellow;
    }

    public void SetupB(DrawableGrid grid, int sceneIndex)
    {
        ship = new ShipB();
        grid.AddObjectToScene(sceneIndex, ship);

        thrust = new ShipBThrust();
        grid.AddObjectToScene(sceneIndex, thrust);

        MaxVelocity = ShipMaxVelocity;

        LaserObject = new Line();
        LaserObject.color = Color.yellow;
    }

    public override void Tick()
    {
        base.Tick();
        UpdateSubObjects();
        UpdateLaser();
    }

    public void UpdateLaser()
    {
        if (!IsDrawingLaser) { return; }

        LaserShowCounter -= Time.deltaTime;

        if (LaserShowCounter < 0)
        {
            IsDrawingLaser = false;
            return;
        }

        LaserObject.start = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), LaserStart);
        LaserObject.end = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), LaserStart);
        SpaceWarGrid.self.DrawLine(LaserObject);
    }
    public void UpdateSubObjects()
    {
        ship.Position = this.Position;
        thrust.Position = this.Position;

        ship.Rotation = this.Rotation;
        thrust.Rotation = this.Rotation;

        ship.Scale = this.Scale;
        thrust.Scale = this.Scale;
    }
     

    public void AddThrust()
    {
        thrust.PerformDraw = true;
        Velocity += DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), 1) * ShipThrust * Time.deltaTime;
    }

    public void NoThrust()
    {
        thrust.PerformDraw = false; 
    }

    public void RotateShip(float value)
    {
        this.Rotation += value * ShipRoation * Time.deltaTime * Mathf.Deg2Rad;
    }
   

    public void FireMissle(DrawableGrid grid, int sceneIndex)
    {
        Missle missleObject = new Missle();
        missleObject.Position = this.Position + DrawingTools.CircleRadiusPoint(Vector3.zero, GetRotationinDegrees(), MissleLaunchAt);
        missleObject.CreateCollision(2, grid, sceneIndex);
        missleObject.LaunchMissle(GetRotationinDegrees());
        grid.AddObjectToScene(sceneIndex, missleObject);
        SpaceWarGrid.self.MovingObjectlist.Add(missleObject);
    }

    public void FireLaser(DrawableGrid grid, int sceneIndex)
    {
        IsDrawingLaser = true;
        LaserShowCounter = 0;
    }
}
