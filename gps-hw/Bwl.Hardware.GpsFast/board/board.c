#include "board.h"

void ir_led_set(char state)
{
	setbit(DDRA,7,1);
	setbit(PORTA,7,state);
}

void ir_modulation_delay()
{
	_delay_us(12.0);
}

void led (byte state)
{
	setbit(DDRB,5,1);
	setbit(PORTB,5,state);
}

int get_state_button(void)
{
	setbit(DDRB,4,0);
	setbit(PORTB,4,1);
	return getbit(PINB,4);	
}


int gps_pps()
{
	setbit(DDRB,3,0);
	setbit(PORTB,3,0);
	return getbit(PINB,3);
}

void gps_power (byte state)
{
	setbit(DDRB,2,1);
	setbit(PORTB,2,state);
	
	setbit(DDRB,4,state);
	setbit(PORTB,4,state);
}

void gps_reset ()
{
	_delay_ms(100);
	setbit(DDRB,4,1);
	setbit(PORTB,4,0);
	_delay_ms(300);
	setbit(DDRB,4,1);
	setbit(PORTB,4,1);	
}

void var_delay_ms(int ms)
{
	for (int i=0; i<ms; i++)_delay_ms(1.0);
}