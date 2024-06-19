using System;

[Flags]
public enum CollisionLayer
{
    None = 0,
    Environment = 1 << 0,
    Player = 1 << 1,
    PhysicalItem = 1 << 2,
    Workbench = 1 << 3,
    PhysicalLoot = 1 << 4,
    Trigger = 1 << 5,
    Everything = ~0,
}
