#ifndef TIMER_MSEC_COUNTER_H_
#define TIMER_MSEC_COUNTER_H_

#include <avr/io.h>

void timer1_setup()
{
	TCCR1A=0;
	TCCR1B=(1<<ICNC1)|(7<<CS10);
	
	//PD5 - T1 -32 khz input
	setbit(PORTD,5,1);
	setbit(DDRD,5,0);
};

uint16_t timer1_read()	{return TCNT1;}

void timer1_clear()		{TCNT1=0;}


#endif /* TIMER_MSEC_COUNTER_H_ */