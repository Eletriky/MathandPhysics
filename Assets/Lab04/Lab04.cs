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


        sceneIndex = AddScene("Diamond scale 20");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);
        newGraph.Scale = (Vector3.one * 20);

        sceneIndex = AddScene("Diamond scale 20");
        newGraph = new DrawableDiamond();
        AddObjectToScene(sceneIndex, newGraph);
        newGraph.Scale = (Vector3.one * 20);
        newGraph.Rotation = 45 * Mathf.Deg2Rad;

        AddScene("Empty Scene, Use Tab To Switch Scenes");
    }


}
