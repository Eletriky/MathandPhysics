using UnityEngine;

public class Lab04 : DrawableGrid
{
    public override void SetupScenes()
    {
        int sceneIndex;
        DrawableArrow newArrow;
        DrawableObject newGraph;

        sceneIndex = AddScene("Diamond");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);
        newGraph.Scale = (Vector3.one * 20);
    }


}
