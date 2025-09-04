#include <Adafruit_MPU6050.h>
#include <Adafruit_Sensor.h>
#include <Wire.h>
#include <Keyboard.h>

Adafruit_MPU6050 mpuRED;
Adafruit_MPU6050 mpuGREEN;

//acceleration along x and z axes for red spatula
float x, z;
//acceleration along x and z for green spatula
float u, s;
unsigned long lastCheckTime = 0;
bool wasUp, wasRight, wasLeft, wasDown, wasUp2, wasRight2, wasLeft2, wasDown2 = false;


void setup() {
  Serial.begin(9600);
  #if defined(__AVR_ATmega32U4__)  // Leonardo
  while (!Serial) {}
  #elif defined(__PIC32MX__)
  delay(1000);
  #endif

  Serial.print("Comm started");

  //check spatulas (accelerometers) are up
  while (!mpuRED.begin(0x68)) {
    Serial.println("RED NOT STARTED");
  }
  Serial.println("RED ON");

  while (!mpuGREEN.begin(0x69)) {
    Serial.println("GREEN NOT STARTED");
  }
  Serial.println("GREEN ON");
  Serial.print("Sensor started");

  mpuRED.setAccelerometerRange(MPU6050_RANGE_16_G);
  mpuRED.setGyroRange(MPU6050_RANGE_250_DEG);
  mpuRED.setFilterBandwidth(MPU6050_BAND_21_HZ);

  mpuGREEN.setAccelerometerRange(MPU6050_RANGE_16_G);
  mpuGREEN.setGyroRange(MPU6050_RANGE_250_DEG);
  mpuGREEN.setFilterBandwidth(MPU6050_BAND_21_HZ);
}

void loop() {
  unsigned long currentTime = millis();
  sensors_event_t a1, g1, temp1;
  sensors_event_t a, g, temp;

  if (currentTime - lastCheckTime >= 80) {
    mpuGREEN.getEvent(&a1, &g1, &temp1);
    mpuRED.getEvent(&a, &g, &temp);

    x = a.acceleration.x;
    z = a.acceleration.z;
    /* spatula controls:
    move down-K, 
    move up/launch-I
    move left-J
    move right-L
    */
    if (z < -2 && !wasDown) {
      Keyboard.write('K');
      wasDown = true;
      wasUp = false;
    } else if (z > 3 && !wasUp) {
      Keyboard.write('I');
      wasUp = true;
      wasDown = false;
    } else if (z <= 3 || z >= -3) {
      wasUp = false;
      wasDown = false;
    }
    if (x < -2 && !wasLeft) {
      Keyboard.write('J');
      wasLeft = true;
      wasRight = false;
    }
    else if (x > 3 && !wasRight) {
      Keyboard.write('L');
      wasRight = true;
      wasLeft = false;
    } else if (x >= -1 || x <= 1) {
      wasRight = false;
      wasLeft = false;
    }

    /* spatula controls:
    move down-S, 
    move up/launch-W
    move left-A
    move right-D
    */
    s = a1.acceleration.x;
    u = a1.acceleration.z;
    if (u < -3 && !wasDown2) {
      Keyboard.write('S');
      wasDown2 = true;
      wasUp2 = false;
    } else if (u > 3 && !wasUp2) {
      Keyboard.write('W');
      wasUp2 = true;
      wasDown2 = false;
    } else if (u >= -3 || u <= 3) {
      wasUp2 = false;
      wasDown2 = false;
    }
    if (s < -1 && !wasLeft2) {
      Keyboard.write('A');
      wasLeft2 = true;
      wasRight2 = false;
    } else if (s > 1 && !wasRight2) {
      Keyboard.write('D');
      wasRight2 = true;
      wasLeft2 = false;
    } else if (s <= 1 || s >= -1) {
      wasRight2 = false;
      wasLeft2 = false;
    }



    lastCheckTime = currentTime;
  }
}
