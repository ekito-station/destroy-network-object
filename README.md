# 他人の生成したネットワークオブジェクトを削除する（PUN2）
PUN2（Photon Unity Networking 2）において、他のプレイヤーが生成したネットワークオブジェクトを削除するやり方を示したサンプルプロジェクトです。
こちらの記事で、やり方の詳細を説明しています。

## DEMO
<p align="center">
  <img width="400" alt="DEMO" src="https://github.com/ekito-station/destroy-network-object/assets/63796528/868c8c1f-b59e-4519-8ec6-4b3e99186f5d">
</p>

## Requirement
- Unity 2021.3.16f1

## Usage
1. photon公式サイトの[ダッシュボード](https://dashboard.photonengine.com/ja-jp)で、新しくアプリを作成しアプリケーションIDを取得します。
2. 取得したアプリケーションIDを、`Assets/Photon/PhotonUnityNetworking/Resources/PhotonServerSettings.asset`の`App Id PUN`に入力します。
<p align="center">
  <img width="400" alt="image" src="https://github.com/ekito-station/destroy-network-object/assets/63796528/01ec9a08-579c-4245-a160-99aa6ff0b304">
</p>

3. Unity Editor上でプロジェクトを実行すると、白い円のオブジェクトが生成されます。
4. プロジェクトをビルドして他の端末でアプリを開くと、白い円のオブジェクトがもう一つ生成されます。Unity Editorから見ると、これが他のプレイヤーの生成したネットワークオブジェクトに当たります。
5. Unity Editor上で、他のプレイヤーの生成したネットワークオブジェクトをクリックすると、削除されます。
