#include <LiquidCrystal_I2C.h>
#include <DHT.h>

#define DHTPIN 2
#define DHTTYPE DHT11

DHT dht(DHTPIN, DHTTYPE);
int temperatura;
int umiditate;

int sensorPin = A0;
int ledRosu = 7;
int ledVerde = 6;
LiquidCrystal_I2C lcd(0x27, 16, 2);

int valoareSenzor = 0; 
void setup() {
  Serial.begin(9600);
  pinMode(ledRosu, OUTPUT); 
  pinMode(ledVerde, OUTPUT);
  lcd.init();
  lcd.clear();
  lcd.backlight();
  dht.begin();
}

void loop(){
  valoareSenzor = analogRead(sensorPin);
  lcd.setCursor(0, 0);
  lcd.print("Nivel hidratare: ");
  Serial.print("Nivel hidratare a solului: ");
  lcd.setCursor(0, 1);
  lcd.print(valoareSenzor);
  Serial.println(valoareSenzor);

  delay(2000);

  lcd.clear();
  temperatura = dht.readTemperature();
  umiditate = dht.readHumidity();
  lcd.setCursor(0, 0);
  lcd.print("Temp: ");
  lcd.print(temperatura);
  lcd.print((char)223);
  lcd.print("C");
  lcd.setCursor(0, 1);
  lcd.print("Umiditatea: ");
  lcd.print(umiditate);
  lcd.print("%  ");

  Serial.print("Hidratare:");
  Serial.print(valoareSenzor);
  Serial.print(";Temperatura:");
  Serial.print(temperatura);
  Serial.print(";Umiditate:");
  Serial.println(umiditate);

  if(valoareSenzor < 400) {
    digitalWrite(ledRosu, LOW);
    digitalWrite(ledVerde, HIGH);
  } 
  else if (valoareSenzor >= 400 && valoareSenzor <= 700)
  {
    digitalWrite(ledRosu, HIGH);
    digitalWrite(ledVerde, LOW);
  }
  else
  {
    digitalWrite(ledRosu, HIGH);
    digitalWrite(ledVerde, LOW);
  }

  delay(3000);
  lcd.clear();
}