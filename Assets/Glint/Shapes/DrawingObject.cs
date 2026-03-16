using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Drawing.Glint;
using System;

[Serializable]
public class DrawingObject
{
    public bool PerformDraw = true;
    public float Roation = 0;
    public Vector3 Scale = Vector3.zero;
    public Vector3 Location = Vector3.zero;
    public List<Line> Lines;

    public DrawingObject()
    {
        Lines = new List<Line>();
        Initalize();
    }
    public virtual void Tick()
    {

    }
    public float GetRotationinDegrees()
    {
        return Roation * Mathf.Rad2Deg;
    }
    public void SetRotationinDegrees(float degrees)
    {
        Roation = degrees * Mathf.Deg2Rad;
    }
    public static float V3ToAngle(Vector3 startPoint, Vector3 endPoint)
    {
        Vector3 dir = endPoint - startPoint;
        return Mathf.Atan2(dir.y, dir.x);
    }
    public static float V3ToAngleinDegrees(Vector3 startPoint, Vector3 endPoint)
    {
        return V3ToAngle(startPoint, endPoint) * Mathf.Rad2Deg;
    }
    public virtual void Initalize()
    {

    }

    /// <summary>
    /// Draws the Drawing Object Instance
    /// </summary>
    /// <param name="grid">Optional, When a Grid2d is applied, object is drawn relative to the grid and location is in Grid space</param>
    public virtual void Draw(Grid2D grid)
    {

        if (!PerformDraw)
        {
           
            return;
        }

       
        if (Lines == null)
        {
           
            return; 
        }

        if (Lines.Count != 0)
        {
           
            for (int i = 0; i < Lines.Count; i++)
            {
              
                grid.DrawLine(Lines[i]);
            }
        
        }
        else
        {
            Debug.Log("No lines");
        }
            
    }
    
}
