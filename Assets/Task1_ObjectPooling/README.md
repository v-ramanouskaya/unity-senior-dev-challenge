1. Click "Prepare Pool" to simulate pool prewarm
2. Click "Spawn objects" to spawn objects
3. The Spawn method produces non-zero allocations due to obj.transform.position = position. This could be resolved by caching the transform references of pooled objects.
However, doing so would compromise the pool's generic design
