using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public struct PlayerData : IEquatable<PlayerData>, INetworkSerializable
{

    public ulong clientId;
    public int colorId;
    public FixedString64Bytes playerName;
    public FixedString64Bytes playerId;

    public bool Equals(PlayerData other) // IEquatable의 구현 함수로 동등성 비교를 정의, NetworkList의 변수로 들어가기 위해 사용
    {
        return clientId == other.clientId 
            && colorId == other.colorId
            && playerName == other.playerName
            && playerId == other.playerId;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter // 데이터 동기화를 위한 직렬화 방식을 정의, ulong은 자동 처리가 안되므로
    {
        serializer.SerializeValue(ref clientId);
        serializer.SerializeValue(ref colorId);
        serializer.SerializeValue(ref playerName);
        serializer.SerializeValue(ref playerId);
    }
}
