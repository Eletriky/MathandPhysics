using UnityEngine;
using Drawing.Glint;

public struct Line : ICommandInstruction
{
	public Vector3 start, end;
	public Color color;
    public bool drawOnGrid;

    public Line(Vector3 start, Vector3 end, Color color, bool drawOnGrid = true)
    {
		this.start = start;
		this.end = end;
		this.color = color;
        this.drawOnGrid = drawOnGrid;
    }

	public GLCommand ToCommand()
	{
		return new GLCommand(DrawMode.Lines, color, start, end);
	}
    public float ScaleGrid2Screen(float value)
    {
        return value;
    }
    public float ScaleScreen2Grid(float value)
    {
        return value;
    }

}