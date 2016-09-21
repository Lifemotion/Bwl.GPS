#include "bwl_ir.h"
#include <avr/io.h>
#include <avr/wdt.h>

void ir_send_bit(char bit)
{
	for (unsigned int i=0; i<15; i++)
	{
		ir_led_set(!bit);
		ir_modulation_delay();
		//ir_led_set(!bit);
		ir_led_set(0);
		ir_modulation_delay();
	}
}

void ir_send(char data)
{
	ir_send_bit(0);
	for (unsigned char i=0; i<8; i++)
	{
		if ((data&1)==0)
		{
			//0
			ir_send_bit(0);
		}else
		{
			//1
			ir_send_bit(1);
		}
		data=data>>1;
	}
	ir_send_bit(1);
	ir_send_bit(1);
}

void ir_send_line(char *string)
{
	ir_send_string(string);
	ir_send_string("\r\n");
}

void ir_send_string(char *string)
{
	unsigned	char  i=0;
	while (string[i]>0)
	{
		ir_send(string[i]);
		i++;
	}
}
