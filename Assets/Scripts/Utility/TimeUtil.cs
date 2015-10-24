using System.Runtime.Remoting.Messaging;
using UnityEngine;
using System.Collections;

public static class TimeUtil
{
	public static int GetMiliseconds(int seconds)
	{
		var miliseconds = seconds * Constants.MILISECOND_MULTIPLIER;

		return miliseconds;
	}
}
