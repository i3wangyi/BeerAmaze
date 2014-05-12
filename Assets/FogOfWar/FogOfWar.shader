Shader "Custom/FogOfWar" {
	Properties {
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB) Trans(A)", 2D) = "white" {}
		_FogRadius ("FogRadius", float) = 100
		_FogMaxRadius("FogMaxRadius", float) = 1
		_Player_Pos ("_Player_Pos", Vector) = (0,0,0,1)
		_Player_Ori ("_Player_Ori", Vector) = (0,0,1,1)
		_LightRadius("LightRadius", float) = 200
	}
	SubShader {
	    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	    LOD 200
	    Blend SrcAlpha OneMinusSrcAlpha
	    Cull Off
	 
	CGPROGRAM
	#pragma surface surf Lambert vertex:vert
	 
	sampler2D _MainTex;
	fixed4 _Color;
	float _FogRadius;
	float _FogMaxRadius;
	float4 _Player_Pos;
	float4 _Player_Ori;
	float _LightRadius;
	struct Input {
	    float2 uv_MainTex;
	    float2 location;
	};
	float powerForPos(float4 pos, float2 nerVertex);
	float oriForPos(float4 pos, float2 nearVertex);
	
	void vert(inout appdata_full vertexData, out Input outData)
	{
		float4 pos =  mul(UNITY_MATRIX_MVP, vertexData.vertex);
		float4 posWorld = mul(_Object2World, vertexData.vertex);
		outData.uv_MainTex = vertexData.texcoord;
		outData.location = posWorld.xz;
	}
	void surf (Input IN, inout SurfaceOutput o) {
	    fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	    //float alpha = (1.0 - powerForPos(_Player_Pos, IN.location));
	    float alpha = 1.0 - oriForPos(_Player_Pos, IN.location);
	    o.Albedo = baseColor.rgb;
	    o.Alpha = alpha;
	}
	float oriForPos(float4 pos, float2 nearVertex)
	{
		float2 vec1 = _Player_Ori.xz;
		float2 vec2 = nearVertex.xy - pos.xz;
		float angle = (vec1.x * vec2.x + vec1.y * vec2.y) / (length(vec1) * length(vec2));
		float atten = (_LightRadius - length(pos.xz - nearVertex.xy));
		
		if(angle > 0.95)
		{
			return atten / _LightRadius;
		}
		else
		{
			atten = (_FogRadius - length(pos.xz - nearVertex.xy));
			return (1.0/_FogMaxRadius)*atten / _FogRadius;
		}
	}
	float powerForPos(float4 pos, float2 nearVertex)
	{
		float atten = (_FogRadius - length(pos.xz - nearVertex.xy));
		return (1.0/_FogMaxRadius)*atten / _FogRadius;
	}
	ENDCG
	}
	 
	Fallback "Transparent/VertexLit"
}