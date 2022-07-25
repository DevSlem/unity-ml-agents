# Unity ML-Agents

You can use environments that i've developed when you train a reinforcement learning agent.

## Development Environment

* Unity Editor: 2021.3.6f1
* [Unity ML-Agents Toolkit: Release 19](https://github.com/Unity-Technologies/ml-agents/tree/release_19)
* Python: 3.7.13
* PyTorch 1.12.0 / CUDA 11.3

> Note: Don't install PyTorch **cpuonly** version. If so, you may not be able to use cuda.

## Structure

* [config](/config/) - Training configuration files
* [Unity ML-Agents Project](/Unity%20ML-Agents%20Project/) - Unity ML-Agents project

## Unity Environments

First of all, Open `Unity ML-Agents Project` in Unity Hub. After it, You can see environments directories in `Assets` folder. You can use them as a two ways to train.

1. build an environment as an executable file
2. directly interact with Unity Editor
