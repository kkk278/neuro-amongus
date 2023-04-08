﻿using System.Collections;

namespace Neuro.Minigames;

public abstract class MinigameSolver
{
    public abstract IEnumerator CompleteMinigame(Minigame minigame, PlayerTask task);
}

public abstract class MinigameSolver<TMinigame> : MinigameSolver where TMinigame : Minigame
{
    public sealed override IEnumerator CompleteMinigame(Minigame minigame, PlayerTask task)
        => CompleteMinigame(minigame.TryCast<TMinigame>(), task.TryCast<NormalPlayerTask>());

    protected abstract IEnumerator CompleteMinigame(TMinigame minigame, NormalPlayerTask task);
}

public abstract class TasklessMinigameSolver<TMinigame> : MinigameSolver where TMinigame : Minigame
{
    public sealed override IEnumerator CompleteMinigame(Minigame minigame, PlayerTask _)
        => CompleteMinigame(minigame.TryCast<TMinigame>());

    protected abstract IEnumerator CompleteMinigame(TMinigame minigame);
}
