
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grid2D : MonoBehaviour
{
    public List<DrawingObject> drawList;

    public Vector3 screenSize;
    public Vector3 origin;
    public Arrow arrow;
    
    public float gridSize = 10f;
    public float minGridSize = 2f;
    public float originSize = .6f;
    
    public int divisionCount = 5;
    public int minDivisionCount = 2;
    
    public Color axisColor = Color.white;
    public Color lineColor = Color.gray;
    public Color divisionColor = Color.yellow;

    public bool isDrawingOrigin = false;
    public bool isDrawingAxis = true;
    public bool isDrawingDivisions = true;
    public bool IsDrawingGrid = true;
    public bool isDrawingObjects = true; 


    private void Start()
    {
     
        screenSize = new Vector3(Screen.width, Screen.height);
        origin = new Vector3(Screen.width / 2, Screen.height / 2);

        drawList = new List<DrawingObject>();
        drawList.Add(new Arrow()); 

    }

    void Update()
    {
        GetInput();
        DrawGrid(); 
        DrawObjects();
    }

    void GetInput()
    {
        Mouse mouse = Mouse.current;
        Keyboard keyboard = Keyboard.current;
        if ( (mouse == null) || (keyboard == null) )
        {
            Debug.LogError("Missing Mouse or Keyboard input");
            return;
        }

        if (mouse.middleButton.wasPressedThisFrame)
        {
            origin = mouse.position.ReadValue();
        }

        float scroll = mouse.scroll.ReadValue().y;

        if (scroll != 0)
        {
            if (keyboard.ctrlKey.isPressed)
            {
                divisionCount += (int)Mathf.Sign(scroll);
                divisionCount = Mathf.Max(divisionCount, minDivisionCount);
            }
            else
            {
                gridSize += scroll;
                gridSize = Mathf.Max(gridSize, minGridSize);
            }
        }
      
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            isDrawingOrigin = !isDrawingOrigin;
        }
        if (keyboard.digit2Key.wasPressedThisFrame)
        {
            isDrawingAxis = !isDrawingAxis;
        }
        if (keyboard.digit3Key.wasPressedThisFrame)
        {
            isDrawingDivisions = !isDrawingDivisions;
        }
        if (keyboard.digit4Key.wasPressedThisFrame)
        {
            IsDrawingGrid = !IsDrawingGrid;
        }
        if (keyboard.digit5Key.wasPressedThisFrame)
        {
            isDrawingObjects = !isDrawingObjects;
        }
    }

    void DrawGrid()
    {
        if (!IsDrawingGrid) {  return; }


        DrawOrigin();

        for (int x = -100; x <= 100; x++)
        {
            Vector3 start = GridToScreen(new Vector3(x, -100, 0));
            Vector3 end = GridToScreen(new Vector3(x, 100, 0));

            Color color = lineColor;

            if (x == 0 && isDrawingAxis)
            {
                color = axisColor;
            }
                
            else if (x % divisionCount == 0 && x != 0 && isDrawingDivisions)
            {
                color = divisionColor;
            }
            DrawLine(start, end, color, false);
        }

        for (int y = -100; y <= 100; y++)
        {
            Vector3 start = GridToScreen(new Vector3(-100, y, 0));
            Vector3 end = GridToScreen(new Vector3(100, y, 0));

            Color color = lineColor;

            if (y == 0 && isDrawingAxis)
            {
                color = axisColor;
            }

            else if (y % divisionCount == 0 && y != 0 && isDrawingDivisions)
            {
                color = divisionColor;
            }
            DrawLine(start, end, color, false);

        }

    }

    public void DrawOrigin()
    {
        if (!isDrawingOrigin)
        { 
            return; 
        }

        Vector3 up = origin + new Vector3(0, originSize * gridSize, 0);
        Vector3 down = origin + new Vector3(0, -originSize * gridSize, 0);
        Vector3 left = origin + new Vector3(-originSize * gridSize, 0, 0);
        Vector3 right = origin + new Vector3(originSize * gridSize, 0, 0);

        DrawLine(up, right, axisColor, false);
        DrawLine(right, down, axisColor, false);
        DrawLine(down, left, axisColor, false);
        DrawLine(left, up, axisColor, false);
    }

    public Vector3 GridToScreen(Vector3 gridSpace)
    {
        
        Vector3 screen = origin; 
        screen += gridSpace * gridSize; 
        return screen;
        
    }
  
    public Vector3 ScreenToGrid(Vector3 screenSpace)
    {
        Vector3 grid = Vector3.zero;
        grid.x = (screenSpace.x - origin.x) / gridSize;
        grid.y = (screenSpace.y - origin.y) / gridSize; 
        return grid;
    }
    
 



    public void DrawLine(Line line, bool drawOnGrid = true)
    {
        if (drawOnGrid)
        {
            DrawLine(line.start, line.end, line.color, drawOnGrid);
        }
        else
        {
            Glint.AddCommand(line);
        }
            
    }

    public void DrawLine(Vector3 start, Vector3 end, Color color, bool drawOnGrid = true)
    {
        if (drawOnGrid)
        {
            Glint.AddCommand(new Line(GridToScreen(start), GridToScreen(end), color, drawOnGrid));
        }
        else
        {
            Glint.AddCommand(new Line(start, end, color, drawOnGrid));
        }

        
    }


    public void DrawObjects()
    {
        if (!isDrawingObjects) { return;  }

        foreach (DrawingObject obj in drawList)
        {
            obj.Draw(this);
        }

    }


}

