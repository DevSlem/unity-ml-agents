# Unity ML-Agents

You can use environments that i've developed when you train a reinforcement learning agent.

## Latest Environment

[Cliff Walking](https://github.com/DevSlem/unity-ml-agents/wiki/Cliff-Walking)

<img src="/Images/cliffwalking.webp" width="60%">

## Development Environment

* Unity Editor: 2021.3.6f1
* [Unity ML-Agents Toolkit: Release 19](https://github.com/Unity-Technologies/ml-agents/tree/release_19)
* Python: 3.7.13

Install the `mlagents` Python package

```
conda install pytorch==1.11.0 torchvision==0.12.0 torchaudio==0.11.0 cudatoolkit=11.3 -c pytorch
python -m pip install mlagents==0.28.0
```

## Unity Environments

First of all, Open the `Unity ML-Agents Project` project. After it, You can see the `Assets/Environments` directory which includes all RL environments. Go to the `Assets/Environments/<Environment Name>/Scenes` folder, if you want to use an environment. Open the scene file of the environment. You can use it as two ways to train.

1. [build an environment as an executable file](https://github.com/Unity-Technologies/ml-agents/blob/release_19_docs/docs/Learning-Environment-Executable.md)
2. directly interact with Unity Editor

You can see descriptions of environments in [Wiki](https://github.com/DevSlem/unity-ml-agents/wiki).

## Structure

* [config](/config/) - Training configuration files
* [Unity ML-Agents Project](/Unity%20ML-Agents%20Project/) - Unity ML-Agents project
