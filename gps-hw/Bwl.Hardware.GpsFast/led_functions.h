#ifndef LED_FUNCTIONS_H_
#define LED_FUNCTIONS_H_

void led_set_time(char h, char m, char s)
{
	for (unsigned char i=2; i<8; i++) digits[i]=0;
	if (h<10) itoa(h,digits+7,10); else itoa(h,digits+6,10);
	if (m<10) itoa(m,digits+9,10); else itoa(m,digits+8,10);
	if (s<10) itoa(s,digits+11,10); else itoa(s,digits+10,10);
}

void led_set_ms(unsigned int ms)
{
	for (unsigned char i=8; i<16; i++) digits[i]=0;
	if (ms<10)			{itoa(ms,digits+15,10);}
	else if (ms<100)	{itoa(ms,digits+14,10);}
	else if (ms<1000)	{itoa(ms,digits+13,10);}
	else				{itoa(ms,digits+12,10);}
}

#endif /* LED_FUNCTIONS_H_ */