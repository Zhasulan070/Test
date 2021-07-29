<template>
       <form class="payment-form" @click="$event.preventDefault()">
            <div class="payment-form__wrapper">
                <div class="payment-form__content">
                  <TheMask :value="value" :masked="false" type="text" :mask="mask" :placeholder="placeholder" @input.native="$emit('input', $event.target.value)"/>
                </div>
                <div class="payment-form__actions" @click="$emit('numberClicked', $event)">
                    <div class="payment-form__item" v-for="number in 9" :key="number"  :data-value="number">{{number}}</div>
                    <div class="payment-form__item payment-form__item--empty"></div>
                    <div class="payment-form__item" data-value="0">0</div>
                    <div class="payment-form__item payment-form__item--yellow" data-value="erase">Erase</div>
                </div>
                <div class="payment-form__submit">
                    <base-button @click="$emit('btnClicked')">{{btnText}}</base-button>
                </div>
            </div>
        </form>
</template>
<script>
import BaseButton from "@/components/Button";
import {TheMask} from 'vue-the-mask'

export default {
    props: {
        value: {
            type: String,
            required: true
        },
        btnText: {
            type: String,
            default: ""
        },
        placeholder: {
            type: String,
            default: ""
        },
        mask: {
            type: String,
            default: "############"
        }
    },
    components: {
        BaseButton,
        TheMask
    }
}
</script>
<style lang="scss" scoped>

    .payment-form{
        max-width: 360px;
        width: 100%;
        min-height: 400px;
        padding: 39px 51px;
        border: 0.5px solid #C4C4C4;
        border-radius: 8px;
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);

        &__content{
            margin-bottom: 34px;

            input{
                width: 100%;
                background: transparent;
                border: none;
                font-weight: bold;
                font-size: 32px;
                line-height: 44px;
                color: #000000;
                text-align: center;
            }
        }

        &__actions{
            display: grid;
            grid-template-columns: repeat(3, 1fr);
            grid-gap: 8px;
        }

        &__item{
            height: 36px;
            line-height: 36px;
            text-align: center;
            background: #E4E4E4;
            border-radius: 5px;
            cursor: pointer;
            $self: &;

            &:hover:not(#{$self}--empty, #{$self}--yellow){
                 background: darken(#E4E4E4, 5%);
            }

            &--empty{
                background: transparent;
                cursor: default;
            }

            &--yellow{
                background: #FCD46F;

                &:hover{
                     background: darken(#FCD46F, 5%);
                }
            }
        }

        &__submit{
            margin-top: 24px;
        }
    }
</style>
