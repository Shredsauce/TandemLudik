using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uniduino;

public class HallEffect : MonoBehaviour {
    private Arduino arduino;
    private int deltaPinValue;
    private float lastRev;

    private float rpm;
    public float smoothedRpm;

    [SerializeField] private int pin = 2;
    [SerializeField] private int pinValue;
    [SerializeField] private int testLed = 13;

    [SerializeField] private float waitThreshold = 1f;

    void Start () {
        arduino = Arduino.global;
        arduino.Log = (s) => Debug.Log("Arduino: " + s);
        arduino.Setup(ConfigurePins);
    }

    void ConfigurePins () {
        arduino.pinMode(pin, 11);
        arduino.reportDigital((byte)(pin / 8), 1);
        // Test LED
        arduino.pinMode(testLed, PinMode.OUTPUT);
    }

    void Update () {
        if (arduino != null) {
            // read the value from the digital input
            pinValue = arduino.digitalRead(pin);
            // apply that value to the test LED
            arduino.digitalWrite(testLed, pinValue);

            float timeSinceLastRev = Time.time - lastRev;

            // Detect a revolution
            if (pinValue == 0 && deltaPinValue == 1) {
                rpm = 60 / timeSinceLastRev;

                Debug.Log(rpm);

                lastRev = Time.time;
            }

            if (timeSinceLastRev > waitThreshold) {
                rpm = 0f;
            }

            smoothedRpm = Mathf.Lerp(smoothedRpm, rpm, (Time.time - lastRev) * Time.deltaTime);
            if (smoothedRpm < 0.001) {
                smoothedRpm = 0;
            }

            deltaPinValue = pinValue;
        }
    }

}
