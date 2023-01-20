using UnityEngine;
using UnityEngine.AI;

public static class NavMeshExtensionClass{
    public static float GetLength(this NavMeshPath path){
        if (path.status != NavMeshPathStatus.PathComplete) return 0;
        
        float distance = 0;
        for (int x = 1; x < path.corners.Length; x++){
            distance += Vector3.Distance(path.corners[x - 1], path.corners[x]);
        }
        return distance;
    }

    public static float GetNavMeshDistanceTo(this Transform source, Transform goal){
        NavMesh.SamplePosition(source.position, out var sourceHit, 10, NavMesh.AllAreas);
        NavMesh.SamplePosition(goal.position, out var goalHit, 10, NavMesh.AllAreas);

        NavMeshPath path = new();
        NavMesh.CalculatePath(sourceHit.position, goalHit.position, NavMesh.AllAreas, path);
        if (path.status != NavMeshPathStatus.PathComplete) return 0;

        return path.GetLength();
    }
}