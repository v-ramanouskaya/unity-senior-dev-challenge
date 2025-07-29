Task 1 — Generic Object Pooling Manager
Goal: Implement a reusable, generic pool of MonoBehaviour instances that never triggers GC at runtime.
a. Spawns 1 000 objects in a circle, holds for 1 s, then releases them.
b. Profiler: “GC Alloc” must stay at 0 KB during spawn & release.

To run:
1. Run ObjectPoolTestScene.unity from Assets/Task1_ObjectPooling/Scenes
2. Click "Prepare Pool" to simulate pool prewarm
3. Click "Spawn objects" to spawn objects
4. The Spawn method produces non-zero allocations due to obj.transform.position = position. This could be resolved by caching the transform references of pooled objects.
However, doing so would compromise the pool's generic design
