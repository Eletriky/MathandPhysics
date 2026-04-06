using UnityEngine;

using Rect = System.Drawing.Rectangle; 

public class lab05Grid : DrawableGrid
{

    Rect box;
    Rect boxOnGrid;

    Vector3 DrawTestPoint;

    Line circleRadiusLine;
    float circleRadius = 10;
    Line ellipseRadiusLine;
    Vector2 ellipseAxis;
    DrawableObject ellipseObject;

    float offset;

    public override void SetupScenes()
    {
        int sceneIndex;
        DrawableObject newObject;

        sceneIndex = AddScene("Drawing Tools Test");

        newObject = DrawingTools.CreateCircleObject(Vector3.zero, 10, 36, Color.blue);
        newObject.Position.y = 15;
        AddObjectToScene(sceneIndex, newObject);

        newObject = DrawingTools.CreateEllipseObject(Vector3.zero, new Vector2(10, 20), 36, Color.blue);
        newObject.Position.x = 30;
        newObject.Position.y = 30;
        ellipseObject = newObject;
        AddObjectToScene(sceneIndex, newObject);

        box = new Rect(100, 100, 100, 100);
        boxOnGrid = new Rect(20, -30, 10, 10);


        offset = 0;

        circleRadiusLine = new Line(Vector3.zero, Vector2.zero, Color.cyan);
        ellipseRadiusLine = new Line(Vector3.zero, Vector2.zero, Color.magenta);

        DrawTestPoint = origin;
        DrawTestPoint.x *= .5f;

        circleRadiusLine.start = ScreenToGrid(DrawTestPoint);
        ellipseRadiusLine.start = ScreenToGrid(DrawTestPoint);

        
    }

    public override void Tick()
    {
        offset += Time.deltaTime;
        DrawingTools.DrawRectangle(box, Color.red);
        DrawingTools.DrawRectangle(boxOnGrid, Color.green, this);

        circleRadiusLine.end = DrawingTools.CircleRadiusPoint(ScreenToGrid(DrawTestPoint), offset * 90, circleRadius);
        DrawLine(circleRadiusLine);
        DrawingTools.DrawCircle(DrawTestPoint, circleRadius * gridSize, 36, Color.white);

        ellipseRadiusLine.end = DrawingTools.EllipseRadiusPoint(ScreenToGrid(DrawTestPoint), offset * 45, ellipseAxis);
        DrawLine(ellipseRadiusLine);

        DrawingTools.DrawEllipse(DrawTestPoint, ellipseAxis * gridSize, 12, Color.grey);

        //DrawingTools.DrawEllipse(DrawTestPoint, ellipseAxis * gridSize, 3, Color.grey);

        ellipseObject.Rotation = offset * 15 * Mathf.Deg2Rad;
    }
}
