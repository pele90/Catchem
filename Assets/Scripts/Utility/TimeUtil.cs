using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;

public static class TimeUtil
{
	public static int GetMiliseconds(int seconds)
	{
		var miliseconds = seconds * Constants.instance.MILISECOND_MULTIPLIER;

		return miliseconds;
	}
}
