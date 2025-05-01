1. Run ObjectPoolTestScene.unity from Assets/Task1_ObjectPooling/Scenes
2. Click "Prepare Pool" to simulate pool prewarm
3. Click "Spawn objects" to spawn objects
4. The Spawn method produces non-zero allocations due to obj.transform.position = position. This could be resolved by caching the transform references of pooled objects.
However, doing so would compromise the pool's generic design
