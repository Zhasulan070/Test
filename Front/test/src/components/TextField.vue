<template>
  <div class="text-block">
    <div class="text-block__field">
      <input
        :type="inputType"
        class="text-block__input"
        ref="input"
        @input="inputHandler($event.target.value)"
        :value="value"
        :class="{ error: hasErrorFeedback }"
        required
        v-if="!withMask"
        @keypress.enter="$emit('enterPressed')"
      />

      <TheMask
        :mask="mask"
        :type="inputType"
        :masked="false"
        :placeholder="inputPlaceholder"
        :value="value"
        @input.native="inputHandler($event.target.value)"
        @focus.native="showPlaceholder = true"
        @blur.native="showPlaceholder = false"
        ref="input"
        class="text-block__input text-block__mask"
        :class="{ error: hasErrorFeedback }"
        required
        v-else
      />

      <div
        class="underlines"
        :class="{ active: !value && !showPlaceholder }"
        v-if="withMask && underlines !== 0"
        :style="{ width: underlines * 7.2 + 'px' }"
      >
        <template v-for="(number, index) in underlines">
          <span :key="index" v-if="!(value.length > index)">_</span>
        </template>
      </div>

      <label for="" class="text-block__label">{{ labelText }}</label>

      <svg
        class="text-block__icon"
        @click="toggleShowPassword"
        v-if="passwordShowable && !showPassword"
      >
        <use
          :xlink:href="require('@/assets/icons/sprite.svg') + '#closedEye'"
        ></use>
      </svg>

      <svg
        class="text-block__icon"
        @click="toggleShowPassword"
        v-if="passwordShowable && showPassword"
      >
        <use
          :xlink:href="require('@/assets/icons/sprite.svg') + '#openedEye'"
        ></use>
      </svg>

      <svg
        class="text-block__icon"
        @click="$emit('input', '')"
        v-if="clearable && value && value.length > 0"
      >
        <use
          :xlink:href="require('@/assets/icons/sprite.svg') + '#clearIcon'"
        ></use>
      </svg>
    </div>

    <div class="text-block__info" v-if="showFeedback">
      <div class="create-info" :class="status">
        <div class="create-info__progress">
          <div class="create-info__indicator"></div>
        </div>
        <div class="create-info__text">
          {{ text }}
        </div>
      </div>
    </div>
    <div class="text-block__error" v-if="hasErrorFeedback">
      {{ errorText }}
    </div>
  </div>
</template>

<script>
import { TheMask } from "vue-the-mask";

export default {
  name: "TextField",
  components: {
    TheMask,
  },
  props: {
    hasErrorFeedback: {
      type: Boolean,
      default: false,
    },
    errorText: {
      type: String,
    },
    signup: {
      type: Boolean,
      default: false,
    },
    labelText: {
      type: String,
      required: true,
    },
    type: {
      type: String,
      default: "text",
    },
    passwordShowable: {
      type: Boolean,
      default: false,
    },
    clearable: {
      type: Boolean,
      default: false,
    },
    value: {
      type: String,
      required: true,
    },
    withMask: {
      type: Boolean,
      default: false,
    },
    mask: {
      type: String,
      default: "8 (###) ### ## ##",
    },
    placeholder: {
      type: String,
      default: "",
    },
    underlines: {
      type: Number,
      default: 0,
    },
  },
  data() {
    return {
      showPassword: false,
      text: "",
      status: "",
      showFeedback: false,
      showPlaceholder: false,
      ownInputValue: "",
    };
  },
  computed: {
    inputType() {
      let inputType = this.type;

      if (this.passwordShowable) {
        inputType = "password";
      }

      return inputType;
    },
    inputPlaceholder() {
      return this.showPlaceholder ? this.placeholder : "";
    },
  },
  methods: {
    toggleShowPassword() {
      if (!this.showPassword) this.showPasswordHandler("text", true);
      else this.showPasswordHandler("password", false);
    },
    showPasswordHandler(type, showPassword) {
      this.$refs.input.type = type;
      this.showPassword = showPassword;
    },
    inputHandler(value) {
      this.$emit("input", value);
      if (this.signup) this.passwordValidationHandler(value);
    },
    passwordValidationHandler(value) {
      if (!this.signup) return;

      this.showFeedback = true;

      if (!value) {
        this.status = "";
        this.showFeedback = false;
        return;
      }

      if (value.length < 5) {
        this.status = "danger";
        this.text = "Низкий уровень защиты";
      } else if (value.length >= 5 && value.length <= 10) {
        this.status = "warning";
        this.text = "Средний уровень защиты";
      } else {
        this.status = "success";
        this.text = "Высокий уровень защиты";
      }
    },
  },
};
</script>

<style scoped lang="scss">
.text-block {
  $self: &;
  position: relative;
  width: 100%;

  &__field {
    position: relative;
    overflow: hidden;
  }

  &__input {
    background: #ffffff;
    border: 1px solid #c4c4c4;
    box-sizing: border-box;
    border-radius: 2px;
    width: 100%;
    height: 48px;
    font-size: 14px;
    line-height: 22px;
    display: flex;
    align-items: center;
    color: #2c3e50;
    padding: 19px 40px 5px 16px;
    transition: 0.3s all;

    &:focus ~ #{$self}__label,
    &:not(:focus):valid ~ #{$self}__label {
      top: 15px;
      font-size: 10px;
      color: #71757a;
    }

    &:focus {
      border: 1px solid #2c3e50;
    }

    &::placeholder {
      font-size: 12px;
    }

    &.error {
      background: #ff2e431f;
    }
  }

  &__mask {
    letter-spacing: 1px;
  }

  &__label {
    position: absolute;
    pointer-events: none;
    left: 16px;
    top: 50%;
    transform: translateY(-50%);
    white-space: nowrap;
    overflow: hidden;
    line-height: 40px;
    transition: 0.3s;
    color: #c4c4c4;
  }

  &__icon {
    position: absolute;
    right: 16px;
    top: 50%;
    transform: translateY(-50%);
    width: 14px;
    height: 14px;
    cursor: pointer;
  }

  &__error {
    font-size: 10px;
    line-height: 14px;
    color: #ff2e43;
    margin-top: 6px;
  }
}

.create-info {
  $self: &;

  margin-top: 9px;
  margin-bottom: 12px;

  &.danger {
    #{$self}__indicator {
      background: #ff2e43;
      width: 33.333%;
    }

    #{$self}__text {
      color: #ff2e43;
    }
  }

  &.warning {
    #{$self}__indicator {
      background: #ffcd33;
      width: 66.666%;
    }

    #{$self}__text {
      color: #fab619;
    }
  }

  &.success {
    #{$self}__indicator {
      background: #00b92d;
      width: 100%;
    }

    #{$self}__text {
      color: #00b92d;
    }
  }

  &__progress {
    height: 1px;
    background: #c4c4c4;
    position: relative;
  }

  &__indicator {
    position: absolute;
    top: 33.333%;
    transform: translateY(-50%);
    height: 2px;
    border-radius: 10px;
  }

  &__text {
    font-style: normal;
    font-weight: normal;
    font-size: 10px;
    line-height: 14px;
    display: flex;
    align-items: center;
    margin-top: 4px;
  }
}

.underlines {
  display: flex;
  position: absolute;
  bottom: 24px;
  left: 40px;
  height: 1px;
  width: 100%;
  pointer-events: none;
  justify-content: flex-end;

  &.active {
    display: none;
  }

  & > div {
    display: flex;
  }

  span {
    display: inline-block;
    margin-right: 2px;
  }
}
</style>
