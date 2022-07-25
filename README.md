# Unity ML-Agents

You can use some environments that i've developed to train reinforcement learning agent.

## Development Environment

* Unity Editor: 2021.3.6f1
* [Unity ML-Agents Toolkit: Release 19](https://github.com/Unity-Technologies/ml-agents/tree/release_19)
* Python: 3.7.13
* PyTorch 1.12.0 / CUDA 11.3

> Note: Don't install PyTorch **cpuonly** version. If so, you may not be able to use cuda.

## Structure

* [Unity ML-Agents Project](/Unity%20ML-Agents%20Project/) - Unity project folder
* [config](/config/) - Training configuration files
* [Training Results](/Training%20Results/) - Training result onnx files


## Unity Environments

직접 만든 Unity Environment들을 간단히 기록함.

### RollerBall

유니티 공식 문서 [Making a New Learning Environment](https://github.com/Unity-Technologies/ml-agents/blob/release_19_docs/docs/Learning-Environment-Create-New.md)에 따라 만든 환경.  
Agent(White Sphere)는 Target(Red Box)에 도달하면 Reward를 획득함.

![](Images/RollerBall/roller-ball.png)
