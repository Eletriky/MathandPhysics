using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DrawableObject : DrawingObject
{

    public bool PerformDraw = true;

    // Transform information 
    public Vector3 Position = Vector3.zero;
    public float Rotation = 0;
    public Vector3 Scale = Vector3.one;

    public List<Line> LineList;

    public DrawableObject()
    {
        LineList = new List<Line>();
        Initalize();
    }

    public virtual void Tick()
    {

    }
    public virtual void Initalize()
    {

    }
    public void AddLineToObject(Line line)
    {
        LineList.Add(line);
    }
    
    public void AddLineToObject(Vector3 start, Vector3 end, Color color)
    {
        LineList.Add(new Line(start, end, color));
    }
    public static float LineToAngle(Line line)
    {
        return V3ToAngle(line.start, line.end);
    }
    public static Vector3 RotatePoint(Vector3 center, Vector3 pointIN, float angleInRadians)
    {
        Vector3 PointAtZero = pointIN - center;
        Vector3 result = Vector3.zero;

        result.x = PointAtZero.x * Mathf.Cos(angleInRadians) - PointAtZero.y * Mathf.Sin(angleInRadians);
        result.y = PointAtZero.x * Mathf.Sin(angleInRadians) + PointAtZero.y * Mathf.Cos(angleInRadians);
        return (result + center);
    }

    /// <summary>
    /// Draws the Drawing Object Instance
    /// </summary>
    /// <param name="grid">Optional, When a Grid2d is applied, object is drawn relative to the grid and location is in Grid space</param>
    public virtual void Draw(DrawableGrid grid)
    {
        if (!PerformDraw) { return; }
        if (LineList == null) { return; }
        if (LineList.Count == 0) { return; }

        for (int i = 0; i < LineList.Count; i++)
        {
            grid.DrawLine(TranslateLinePoints(LineList[i]));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="line"></param>
    /// <returns>given line translated by scale, rotation, postion</returns>
    public Line TranslateLinePoints(Line line)
    {
        Line translatedLine = line;

        // Rotate
        translatedLine.start = RotatePoint(Vector3.zero, translatedLine.start, Rotation);
        translatedLine.end = RotatePoint(Vector3.zero, translatedLine.end, Rotation);
        // Scale
        translatedLine.start.x *= Scale.x;
        translatedLine.start.y *= Scale.y;
        translatedLine.start.z *= Scale.z;

        translatedLine.end.x *= Scale.x;
        translatedLine.end.y *= Scale.y;
        translatedLine.end.z *= Scale.z;
        // Position
        translatedLine.start += Position;
        translatedLine.end += Position;

        

        return translatedLine;
    }
}