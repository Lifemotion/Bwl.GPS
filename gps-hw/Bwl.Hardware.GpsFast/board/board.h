#ifndef BOARD_H_
#define BOARD_H_

#define F_CPU 16000000UL

#include <avr/io.h>
#include <util/delay.h>
#include <avr/wdt.h>

#include <stdlib.h>
#include <string.h>

#define getbit(port, bit)		((port) &   (1 << (bit)))
#define setbit(port,bit,val)	{if ((val)) {(port)|= (1 << (bit));} else {(port) &= ~(1 << (bit));}}

typedef unsigned char byte;

void led (byte state);

void gps_power (byte state);
int get_state_button();
int gps_pps();
void gps_reset ();
void var_delay_ms(int ms);

#endif /* BOARD_H_ */