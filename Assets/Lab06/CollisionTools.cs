using System.Collections.Generic;
using UnityEngine;

using Rect = System.Drawing.Rectangle;
public static class CollisionTools
{
    public static void DrawTriangle(TriangleData data, Color color, DrawableGrid grid = null)
    {
        Line lineA = new Line(data.PointA, data.PointB, color);
        Line lineB = new Line(data.PointB, data.PointC, color);
        Line lineC = new Line(data.PointC, data.PointA, color);

        if (grid == null)
        {
            // Info is in Screen Space 
            Glint.AddCommand(lineA);
            Glint.AddCommand(lineB);
            Glint.AddCommand(lineC);
        }
        else
        {
            grid.DrawLine(lineA);
            grid.DrawLine(lineB);
            grid.DrawLine(lineC);
        }
    }

    public static void SetColor(DrawableObject thing, Color color)
    {
        for (int i = 0; i < thing.LineList.Count; i++)
        {
            Line item = thing.LineList[i];
            item.color = color;
            thing.LineList[i] = item;

            // C# is acting weird... 
            // won't let me use foreach
            // wont' let me do LineList[i].color = color; 
        }
    }

    public static bool IsPointInCircle(Vector3 Point, Vector3 Center, float Radius)
    {
        float distSq = (Point - Center).sqrMagnitude;
        return distSq <= Radius * Radius;

    }

    public static bool IsPointInRectangle(Vector3 Point, Rect Rectangle)
    {
        return
        Point.x >= Rectangle.X && Point.x <= Rectangle.X + Rectangle.Width &&
        Point.y >= Rectangle.Y && Point.y <= Rectangle.Y + Rectangle.Height;
    }
    private static bool SameSide(Vector3 p1, Vector3 p2, Vector3 a, Vector3 b)
    {
        Vector3 cp1 = Vector3.Cross(b - a, p1 - a);
        Vector3 cp2 = Vector3.Cross(b - a, p2 - a);
        return Vector3.Dot(cp1, cp2) >= 0;
    }

    public static bool IsPointInTriangle(Vector3 Point, TriangleData Triangle)
    {
        Vector3 A = Triangle.PointA;
        Vector3 B = Triangle.PointB;
        Vector3 C = Triangle.PointC;

        bool side1 = SameSide(Point, C, A, B);
        bool side2 = SameSide(Point, A, B, C);
        bool side3 = SameSide(Point, B, C, A);

        return side1 && side2 && side3;

    }

    public static bool DoesLineIntersectCircle(Vector3 LineStart, Vector3 LineEnd, Vector3 CircleCenter, float CircleRadius)
    {
        // Stub Code
        return false;
    }

    public static bool DoesLineIntersectCircle(Vector3 LineStart, Vector3 LineEnd, Vector3 CircleCenter, float CircleRadius, DrawableObject Intersect1, DrawableObject Intersect2)
    {
        // Stub Code
        return false;
    }

    public static List<Vector3> IntersectionPoint(Vector3 p1, Vector3 p2, Vector3 center, float radius)
    {
        List<Vector3> result = new List<Vector3>();
        return result;
    }
    public static bool IsInLineSegment(Vector3 point, Vector3 start, Vector3 end)
    {
        // Stub Code
        return false;
    }
}
